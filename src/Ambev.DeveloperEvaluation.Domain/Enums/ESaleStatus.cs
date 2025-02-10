namespace Ambev.DeveloperEvaluation.Domain.Enums
{
    /// <summary>
    /// Represents the possible statuses of a sale.
    /// </summary>
    public enum ESaleStatus
    {
        /// <summary>
        /// The sale has been created successfully.
        /// </summary>
        Created, 

        /// <summary>
        /// The sale is pending and has not yet been completed.
        /// </summary>
        Pending,

        /// <summary>
        /// The sale has been completed successfully.
        /// </summary>
        Completed,

        /// <summary>
        /// The sale has been canceled.
        /// </summary>
        Canceled,

        /// <summary>
        /// The sale is in a state of failure (e.g., payment failed).
        /// </summary>
        Failed,

        /// <summary>
        /// The sale is in the process of being shipped.
        /// </summary>
        Shipping,

        /// <summary>
        /// The sale has been delivered to the customer.
        /// </summary>
        Delivered,

        Unknown
    }
}
