﻿using Microsoft.SharePoint.Client;
using PnP.Framework.Utilities;
using PnP.PowerShell.Commands.Pages;
using System;

namespace PnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class ClassicPagePipeBind
    {
        private const string CAMLQueryByExtensionAndName = @"
                <View Scope='Recursive'>
                  <Query>
                    <Where>
                      <Eq>
                        <FieldRef Name='FileLeafRef'/>
                        <Value Type='text'>{0}</Value>
                      </Eq>
                    </Where>
                  </Query>
                </View>";

        private const string CAMLQueryForBlogByTitle = @"
                <View Scope='Recursive'>
                  <Query>
                    <Where>
                      <BeginsWith>
                        <FieldRef Name='Title'/>
                        <Value Type='text'>{0}</Value>
                      </BeginsWith>
                    </Where>
                  </Query>
                </View>";

        private ListItem pageListItem;
        private string name;

        public ClassicPagePipeBind(ListItem pageListItem)
        {
            this.pageListItem = pageListItem;
            this.name = null;
        }

        public ClassicPagePipeBind(string name)
        {
            this.name = name;
            this.pageListItem = null;
        }

        public ListItem PageListItem => this.pageListItem;

        public string Name => this.name;

        public string Library { get; set; }

        public string Folder { get; set; }

        public bool BlogPage { get; set; }

        public bool DelveBlogPage { get; set; }

        internal ListItem GetPage(Web web, string listToLoad)
        {
            bool loadViaId = false;
            int idToLoad = -1;

            // Check what we got via the pagepipebind constructor and prep for getting the page
            if (!string.IsNullOrEmpty(this.name))
            {
                if (int.TryParse(this.Name, out int pageId))
                {
                    idToLoad = pageId;
                    loadViaId = true;
                }
                else
                {
                    if (!this.BlogPage && !this.DelveBlogPage)
                    {
                        this.name = PageUtilities.EnsureCorrectPageName(this.name);
                    }
                    this.pageListItem = null;
                }
            }
            else if (this.pageListItem != null)
            {
                if (this.pageListItem != null)
                {
                    if (this.BlogPage || this.DelveBlogPage)
                    {
                        this.name = this.pageListItem.FieldValues["Title"].ToString();
                    }
                    else
                    {
                        this.name = this.pageListItem.FieldValues["FileLeafRef"].ToString();
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.Library))
            {
                listToLoad = this.Library;
            }

            // Blogs live in a list, not in a library
            if (this.BlogPage && !listToLoad.StartsWith("lists/", StringComparison.InvariantCultureIgnoreCase))
            {
                listToLoad = $"lists/{listToLoad}";
            }

            web.EnsureProperty(w => w.ServerRelativeUrl);
            var listServerRelativeUrl = UrlUtility.Combine(web.ServerRelativeUrl, listToLoad);

            List libraryContainingPage = null;

            libraryContainingPage = web.GetList(listServerRelativeUrl);

            if (libraryContainingPage != null)
            {
                if (loadViaId)
                {
                    var page = libraryContainingPage.GetItemById(idToLoad);
                    web.Context.Load(page);
                    web.Context.ExecuteQueryRetry();
                    return page;
                }
                else
                {
                    CamlQuery query = null;
                    if (!string.IsNullOrEmpty(this.name))
                    {
                        if (this.BlogPage || this.DelveBlogPage)
                        {
                            query = new CamlQuery
                            {
                                ViewXml = string.Format(CAMLQueryForBlogByTitle, System.Text.Encodings.Web.HtmlEncoder.Default.Encode(this.name))
                            };
                        }
                        else
                        {
                            query = new CamlQuery
                            {
                                ViewXml = string.Format(CAMLQueryByExtensionAndName, System.Text.Encodings.Web.HtmlEncoder.Default.Encode(this.name))
                            };
                        }

                        if (!string.IsNullOrEmpty(this.Folder))
                        {
                            libraryContainingPage.EnsureProperty(p => p.RootFolder);
                            query.FolderServerRelativeUrl = $"{libraryContainingPage.RootFolder.ServerRelativeUrl}/{Folder}";
                        }

                        var page = libraryContainingPage.GetItems(query);
                        web.Context.Load(page);
                        web.Context.ExecuteQueryRetry();

                        if (page.Count >= 1)
                        {
                            // Return the first match
                            return page[0];
                        }
                    }
                }
            }

            return null;
        }
    }
}