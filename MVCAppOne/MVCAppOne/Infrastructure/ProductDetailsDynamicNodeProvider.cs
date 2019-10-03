using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAppOne.DAL;
using MVCAppOne.Models;
using MvcSiteMapProvider;

namespace MVCAppOne.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Album a in db.Albums)
            {
                DynamicNode n = new DynamicNode();
                n.Title = a.AlbumTitle;
                n.Key = "Album_" + a.AlbumID;
                n.ParentKey = "Genre_" + a.GenreID;
                n.RouteValues.Add("id", a.AlbumID);

                returnValue.Add(n);
            }

            return returnValue;
            
        }
    }
}