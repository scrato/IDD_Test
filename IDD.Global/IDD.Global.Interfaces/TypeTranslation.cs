using IDD.Global.Exceptions;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public enum PaketType
    {
        ConnectionInfo,
        NewPlayerInfo,
        UserInformInfo,
        IsAliveRequest,
        FileUpload,
        TableUpload,
        Message,
        PersonalMessage
        

    }

        public class TypeTranslation : ITypeTranslator
        {

            private  const int ConnectionInfo = 100;
            private const int NewPlayerInfo = 101;
            private const int UserInformInfo = 102;
            private const int IsAliveRequest = 103;
            private  const int FileUpload = 200;
            private  const int TableUpload = 300;
            private  const int Message = 400;
            private const int PersonalMessage = 401;

            public PaketType translateType(int msgId)
            {
                switch (msgId)
                {
                    case ConnectionInfo:
                        return PaketType.ConnectionInfo;
                    case NewPlayerInfo:
                        return PaketType.NewPlayerInfo;
                    case UserInformInfo:
                        return PaketType.UserInformInfo;
                    case IsAliveRequest:
                        return PaketType.IsAliveRequest;
                    case FileUpload:
                        return PaketType.FileUpload;
                    case TableUpload:
                        return PaketType.TableUpload;
                    case Message:
                        return PaketType.Message;
                    case PersonalMessage:
                        return PaketType.PersonalMessage;
                    default:
                        throw new TypeNotKnownException("Unbekannte ID: " + msgId);
                }
            }

            public int translateType(PaketType type)
            {
                switch (type)
                {
                    case PaketType.ConnectionInfo:
                        return ConnectionInfo;
                    case PaketType.NewPlayerInfo:
                        return NewPlayerInfo;
                    case PaketType.UserInformInfo:
                        return UserInformInfo;
                    case PaketType.IsAliveRequest:
                        return IsAliveRequest;
                    case PaketType.FileUpload:
                        return FileUpload;
                    case PaketType.TableUpload:
                        return TableUpload;
                    case PaketType.Message:
                        return Message;
                    case PaketType.PersonalMessage:
                        return PersonalMessage;
                    default:
                        throw new TypeNotKnownException("Unbekannter Typ: " + type.ToString());
                }
            }
        }
}
