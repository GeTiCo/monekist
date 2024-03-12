using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monekist.Classes
{
    internal class ProductExtended
    {
        public Model.product Product { get; set; }

        public string PhotoCorrect
        {
            get
            {
                if (!File.Exists(Environment.CurrentDirectory + "/Images/" + Product.productImage))
                    return "/Resources/picture.png";
                return Environment.CurrentDirectory + "/Images/" + Product.productImage;
            }
        }
    }
}
