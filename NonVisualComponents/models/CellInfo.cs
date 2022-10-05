using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonVisualComponents.models
{
    public class CellInfo
    {
        public int StartIndex
        {
            get;
        }
        public int EndIndex
        {
            get;
        }
        public int Index
        {
            get;
        }
        public string Data
        {
            get;
        }
        public bool HorizontalMerged
        {
            get;
        }
        public CellInfo(string data, int startIndex, int endIndex)
        {
            HorizontalMerged = true;
            Data = data;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Index = startIndex;
        }
        public CellInfo(string data, int index)
        {
            HorizontalMerged = false;
            Data = data;
            Index = index;
        }
    }
}
