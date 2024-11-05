namespace Thriving.Win32Tools
{
    public enum WaitState : uint
    {
        /// <summary>
        /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated. Ownership of the mutex object is granted to the calling thread and the mutex is set to nonsignaled.
        ///If the mutex was protecting persistent state information, you should check it for consistency.
        /// </summary>
        WAIT_ABANDONED = 0x00000080,

        /// <summary>
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// </summary>
        WAIT_IO_COMPLETION = 0x000000C0,
        /// <summary>
        /// The state of the specified object is signaled.
        /// </summary>
        WAIT_OBJECT_0 = 0x00000000,
        /// <summary>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </summary>
        WAIT_TIMEOUT = 0x00000102,
        /// The function has failed. To get extended error information, call GetLastError.
        WAIT_FAILED = 0xFFFFFFFF,
    }
    public enum MutexAccessRight:long
    {
        /// <summary>
        /// All possible access rights for a mutex object. Use this right only if your application requires access beyond that granted by the standard access rights. Using this access right increases the possibility that your application must be run by an Administrator.
        /// </summary>
        MUTEX_ALL_ACCESS = 0x1F0001,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        MUTEX_MODIFY_STATE = 0x0001
    }
}
