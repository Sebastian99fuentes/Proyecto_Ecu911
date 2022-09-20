using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Ecu911.Servicios
{
    public class EncodingHelper
    {
        public string JsonSpanishSerializer(object objeto, Type type)
        {
            try
            {
                string value = JsonSerializer.Serialize(objeto, type, new JsonSerializerOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement)
                });
                return value;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string JsonSpanishSerializerWithReferences(Object objeto, Type type)
        {
            try
            {
                string value = JsonSerializer.Serialize(objeto, type, new JsonSerializerOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
                    ReferenceHandler = ReferenceHandler.Preserve
                });
                return value;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public JsonSerializerOptions WithReferences(){
            return new JsonSerializerOptions{
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
                ReferenceHandler = ReferenceHandler.Preserve
            };
        }

        public JsonSerializerOptions WithoutReferences(){
            return new JsonSerializerOptions{
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
        }
    }
}
