namespace Kdd.Common.Enums
{
    public enum IntervalType
    {
        /// <summary>
        /// Interval that includes both start & end point: [-1, 1]
        /// </summary>
        Closed,
        /// <summary>
        /// Interval that includes start point: [-1, 1)
        /// </summary>
        StartClosed,
        /// <summary>
        /// Interval that includes end point: (-1, 1]
        /// </summary>
        EndClosed,
        /// <summary>
        /// Interval that doesn't include both start & end point: (-1, 1)
        /// </summary>
        Open
    }
}