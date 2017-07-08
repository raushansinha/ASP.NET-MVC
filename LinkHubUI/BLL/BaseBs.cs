using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {

        public UserBs userBs { get; set; }
        public CategoryBs categoryBs { get; set; }
        public UrlBs urlBs { get; set; }

        public BaseBs()
        {
            urlBs = new UrlBs();
            categoryBs = new CategoryBs();
            userBs = new UserBs();
        }
    }
}
