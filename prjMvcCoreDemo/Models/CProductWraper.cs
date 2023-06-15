using System.ComponentModel;

namespace prjMvcCoreDemo.Models
{
    public class CProductWraper
    {
        private TProduct _product;
        public CProductWraper()
        {
            if (_product == null)
                _product = new TProduct();
        }
        public TProduct product {
            get { return _product; }
            set { _product = value; }
        }
        public int FId { 
            get { return _product.FId; }
            set { _product.FId = value; }
        }
        [DisplayName("品名")]
        public string? FName
        {
            get { return _product.FName; }
            set { _product.FName = value; }
        }

        public int? FQty
        {
            get { return _product.FQty; }
            set { _product.FQty = value; }
        }

        public decimal? FCost
        {
            get { return _product.FCost; }
            set { _product.FCost = value; }
        }

        public decimal? FPrice
        {
            get { return _product.FPrice; }
            set { _product.FPrice = value; }
        }

        public string? FImagePath
        {
            get { return _product.FImagePath; }
            set { _product.FImagePath = value; }
        }
        public IFormFile photo { get; set; }
    }
}
