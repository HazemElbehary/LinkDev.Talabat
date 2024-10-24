namespace LinkDev.Talabat.Core.Domain.Contracts.DbInitializers
{
	public interface IDbInitializer
	{
		Task InitializeAsync();
		Task SeedAsync();
	}
}
