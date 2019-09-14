using System;

namespace AddressBook.Api.Models
{
    public class Seriloger
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        public string Level { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }

        //public static explicit operator LogView(Seriloger obj)
        //{
        //    LogView output = new LogView() { Id = obj.Id, Message = obj.Message, TimeStamp = obj.TimeStamp };
        //    return output;
        //}
    }
}
