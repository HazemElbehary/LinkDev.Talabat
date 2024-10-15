namespace LinkDev.Talabat.APIs.Controllers.Errors
{
	public class NotFoundException : ApplicationException
	{
        public NotFoundException() : base("Not Found")
        {
        }
    }
}
