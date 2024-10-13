namespace LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product
{
	public class ProductSpecParams
	{

        const int MaxSize = 10;

        public string? sort { get; set; }
        public int? brandId { get; set; }
        public int? categoryId { get; set; }

        public int Take { get; set; }
		public int Skip { get; set; }
		public bool IsPaginate { get; set; }

        public int pageIndex { get; set; } = 1;

        int PageSize = 5;
        public int pageSize 
        {
            get {return PageSize;}
            set { PageSize = value > MaxSize ? MaxSize : value ;}
        }

    }
}
