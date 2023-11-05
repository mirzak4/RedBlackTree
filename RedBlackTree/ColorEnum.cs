using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedBlackTree
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum ColorEnum
    {
        [JsonProperty(PropertyName = "red")]
        Red,
        [JsonProperty(PropertyName = "black")]
        Black
    }
}
