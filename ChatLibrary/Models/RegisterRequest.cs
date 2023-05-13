using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatLibrary.Models;

    public class RegisterRequest : IDataMessage
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DataMessage ToMessage()
        {
            return new DataMessage()
            {
                Type = DataType.RegisterRequest,
                Data = JsonSerializer.Serialize(this)
            };
        }
    }

