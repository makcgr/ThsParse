namespace ParseTHSMsg
{
    public enum SourceType
    {
        Unknown = 0,
        SIPServer,
        AMS,
        RTSM,
        RTSM_in_thslog,
        Tpdrv,
        Tns,
        Ths,        
        Buddy
    }

    public class ACSLogFile
    {
        public string LogFileName;
        public SourceType SourceType;
        public MessageMatcherSettings MatcherSettings;
    }
}
