using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.MVC.Models
{
    public class NestedPartialViewModel
    {

        public string Value { get; set; }

        public NestedPartialViewModel Parent { get; set; }

        public List<NestedPartialViewModel> Children { get; set; } = new List<NestedPartialViewModel>();


        public int GetDepth()
        {
            int depth = 1;
            NestedPartialViewModel p = Parent;
            while (p != null)
            {
                depth++;
                p = p.Parent;
            }

            return depth;

        }
    }
}