namespace RecordShop.Model
{
    public class RecordShopException : Exception
    {
        public ErrorStatus Status { get; }

        public RecordShopException(ErrorStatus status, string message)
            : base(message)
        {
            Status = status;
        }
    }
}
