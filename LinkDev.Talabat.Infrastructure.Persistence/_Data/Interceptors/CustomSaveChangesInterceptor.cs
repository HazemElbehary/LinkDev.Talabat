using LinkDev.Talabat.Core.Application.Abstraction.LoggedInUserServices;
using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Interceptors
{
	public class CustomSaveChangesInterceptor(ILoggedInUserService loggedInUserService) : SaveChangesInterceptor
	{
		public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
		{
			SetAuditeData(eventData.Context);
			return base.SavedChanges(eventData, result);
		}

		public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
		{
			SetAuditeData(eventData.Context);
			return base.SavedChangesAsync(eventData, result, cancellationToken);
		}

		private void SetAuditeData(DbContext dbContext)
		{
			foreach (var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity<int>>().Where(E => E.State is EntityState.Added or EntityState.Modified))
			{
				var entity = entry.Entity;
				if (entry.State is EntityState.Added)
				{
					entity.CreatedBy = loggedInUserService.UserId!;
					entity.CreatedOn = DateTime.UtcNow;
				}

				entity.LastModifiedOn = DateTime.UtcNow;
				entity.LastModifiedBy = loggedInUserService.UserId!;
			}
		}
	}
}