namespace effectively.StaticCling {
    using System;

    public class Logger {
        public static Logger Instance = new Logger();
        public virtual void LogInternal(string message)
        {
            throw new Exception("Actual logging!");
        }

        public static void Log(string message) {
            Instance.LogInternal(message);
        }
    }
}
