public enum ServerCommand : byte
{
    DISCONNECT_ME = 0x1,
    NEW_MESSAGE = 0x2,
    CLOSE_CONNECTION = 0x3,
    NEW_CONNECTION = 0x4,
    CLOSE_SERVER = 0x5,
}