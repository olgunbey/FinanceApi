using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.IRepository.IHashRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Infrastructure.HashRepository
{
    public class HashRepository : IHash
    {
        public string DecodeFrom64(string encodedData) //encoded olan şifreyi çevirir
        {
            var encoder = new UTF8Encoding();
            var utf8Decode= encoder.GetDecoder();
            var todecode_byte= Convert.FromBase64String(encodedData);
            int charCount=utf8Decode.GetCharCount(todecode_byte,0,todecode_byte.Length);
            char[] decoded_char=new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result=new string(decoded_char);
            return result;
        }

        public string EncodePasswordToBase64(string password) //şifreyi encoded haline getirir
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte=Encoding.UTF8.GetBytes(password);
                string encodedData=Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new EncodException("error is base64Encode " + e.Message);
            }
        }
    }
}
