using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Symbol.RFID3;
using System.Collections;

namespace RFID_Manager
{
    public interface ITagProcessor
    {
        void updateTag(TagData tag);
        void processTag(TagData tag);
    }
}
