using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.BasePage
{
    public class BasePage
    {
        protected Dsl dsl;

        public BasePage()
        {
            dsl = new Dsl();
        }
    }
}
