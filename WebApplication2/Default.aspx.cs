using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetSelecct2List(string title, int pageNumber, int pageSize)
        {
            var blogs = BlogsSelect2(title, pageNumber, pageSize);
            Select2Pagination pagination = new Select2Pagination()
            {
                more = blogs.HasNextPage
            };

            Select2ModelResult modelResult = new Select2ModelResult()
            {
                results = blogs.ToList(),
                pagination = pagination
            };
            return JsonConvert.SerializeObject(modelResult);
        }


        public static IPagedList<Select2Model> BlogsSelect2(string title, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(title))
            {
                return select2Models
                .Select(x => new Select2Model()
                {
                    id = x.id,
                    text = x.text
                }).ToPagedList(pageNumber: pageNumber, pageSize: pageSize);
            }
            else
            {
                return select2Models
                .Where(b => b.text != null && b.text != "" && b.text.ToLower().Contains(title.ToLower()))
                .Select(x => new Select2Model()
                {
                    id = x.id,
                    text = x.text
                }).ToPagedList(pageNumber: pageNumber, pageSize: pageSize);
            }
        }


        public class Select2Model
        {
            public string id { get; set; }
            public string text { get; set; }
        }

        public class Select2Pagination
        {
            public bool more { get; set; }
        }

        public class Select2ModelResult
        {
            public List<Select2Model> results { get; set; }
            public Select2Pagination pagination { get; set; }

        }

        static List<Select2Model> select2Models = new List<Select2Model>()
        {
            new Select2Model(){id="A", text="tA"},
            new Select2Model(){id="B", text="tB"},
            new Select2Model(){id="C", text="tC"},
            new Select2Model(){id="D", text="tD"},
            new Select2Model(){id="E", text="tE"},
            new Select2Model(){id="F", text="tF"},
            new Select2Model(){id="G", text="tG"},
            new Select2Model(){id="H", text="tH"},
            new Select2Model(){id="I", text="tI"},
            new Select2Model(){id="J", text="tJ"},
            new Select2Model(){id="K", text="tK"},
            new Select2Model(){id="L", text="tL"},
            new Select2Model(){id="M", text="tM"},
            new Select2Model(){id="N", text="tN"},
            new Select2Model(){id="O", text="tO"},
            new Select2Model(){id="P", text="tP"},
            new Select2Model(){id="Q", text="tQ"},
            new Select2Model(){id="R", text="tR"},
            new Select2Model(){id="S", text="tS"},
            new Select2Model(){id="T", text="tT"},
            new Select2Model(){id="U", text="tU"},
        };
    }
}