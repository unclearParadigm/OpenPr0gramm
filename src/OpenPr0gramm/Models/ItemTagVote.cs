using OpenPr0gramm.Structures;

namespace OpenPr0gramm.Models
{
#if FW
    [Serializable]
#endif
    public class ItemTagVote
    {
        public string User { get; set; }
        public Vote Vote { get; set; }
    }
}
