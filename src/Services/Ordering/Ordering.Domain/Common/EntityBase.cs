namespace Ordering.Domain.Common
{
	public abstract class EntityBase
	{
		public int Id { get; protected set; }
		public string CreatedBy { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		public string LastModifiedBy { get; set; } = string.Empty;
		public DateTime? LastModifiedDate { get; set; }= DateTime.UtcNow;
	}
}
