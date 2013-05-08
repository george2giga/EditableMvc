using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace EditableMvc
{
    [Serializable]
    public class EditableContent
    {

        [IgnoreDataMember]
        private DateTime _dateOfCreation = DateTime.Today;
        public string Id { get; set; }

        public DateTime CreatedDate
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; }
        }
        public DateTime ModifiedDate { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}