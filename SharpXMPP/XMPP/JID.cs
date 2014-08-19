﻿namespace SharpXMPP.XMPP
{
    public partial class JID
    {
        public string User { get; set; }
        public string Domain { get; set; }
        public string Resource { get; set; }

        public JID()
        {

        }
        
        public JID(string jid)
        {
            var delimiters = new[] { '@', '/' };
            var parts = jid.Split(delimiters);
            switch (parts.Length)
            {
                case 1:
                    Domain = parts[0];
                    break;
                case 2:
                    User = parts[0];
                    Domain = parts[1];
                    break;
                case 3:
                    User = parts[0];
                    Domain = parts[1];
                    Resource = parts[2];
                    break;
            }
        }

        public string BareJid
        {
            get { return string.IsNullOrEmpty(User) ? Domain : string.Format(@"{0}@{1}", User, Domain); }
        }

        public string FullJid
        {
            get { return string.IsNullOrEmpty(Resource) ? BareJid : string.Format(@"{0}/{1}", BareJid, Resource); }
        }

        public string ToString()
        {
            return FullJid;            
        }
    }
}
