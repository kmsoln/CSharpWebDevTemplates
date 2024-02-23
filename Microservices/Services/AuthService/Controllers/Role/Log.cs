namespace AuthService.Controllers.Role;

public partial class RoleController
{
    /// <summary>
    ///     Logs messages with the specified log level for the controller.
    /// </summary>
    /// <param name="level">The log level for the message. Acceptable values are:</param>
    /// <list type="bullet">
    ///     <item>
    ///         <term>
    ///             <b>TRACE</b>
    ///         </term>
    ///         <description>
    ///             The most detailed log level, providing <i>fine-grained information</i> about the execution flow.
    ///             Used for <i>debugging purposes</i> and may produce a <i>large volume</i> of log output.
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <term>
    ///             <b>DEBUG</b>
    ///         </term>
    ///         <description>
    ///             A level used for messages that are helpful during <i>development and debugging</i>.
    ///             Provides information about the application's <i>internal state, variable values</i>, etc.
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <term>
    ///             <b>INFO</b>
    ///         </term>
    ///         <description>
    ///             General <i>informational messages</i> that signify the <i>normal execution</i> of the application.
    ///             Typically used to communicate <i>significant events</i> such as application startup, successful operations,
    ///             or key milestones.
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <term>
    ///             <b>WARN</b>
    ///         </term>
    ///         <description>
    ///             Indicates potential issues that are not errors but may require <i>attention</i>.
    ///             Suggests that there might be a <i>problem</i> that needs to be addressed to prevent future errors or
    ///             unexpected behavior.
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <term>
    ///             <b>ERROR</b>
    ///         </term>
    ///         <description>
    ///             Represents <i>errors</i> that occurred during the execution of the application.
    ///             These messages indicate issues that need <i>investigation</i> and may impact the normal functioning of the
    ///             application.
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <term>
    ///             <b>FATAL</b>
    ///         </term>
    ///         <description>
    ///             The most <i>severe log level</i>, indicating a <i>critical error</i> that leads to the termination of the
    ///             application or a major failure.
    ///             Fatal log messages often represent situations where the application <i>cannot recover</i>.
    ///         </description>
    ///     </item>
    /// </list>
    /// <param name="message">The message to be logged.</param>
    private void Log(LogLevel level, string message)
    {
        logger.Log(level, $"[{nameof(RoleController)}] {message}");
    }
}