public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        byte[] bytes;

        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            buffer[0] = 2;
            bytes = BitConverter.GetBytes((ushort)reading);
        }
        else if (reading >= short.MinValue && reading < 0)
        {
            buffer[0] = 256 - 2;
            bytes = BitConverter.GetBytes((short)reading);
        }
        else if (reading >= int.MinValue && reading < short.MinValue)
        {
            buffer[0] = 256 - 4;
            bytes = BitConverter.GetBytes((int)reading);
        }
        else if (reading > ushort.MaxValue && reading <= int.MaxValue)
        {
            buffer[0] = 256 - 4;
            bytes = BitConverter.GetBytes((int)reading);
        }
        else if (reading > int.MaxValue && reading <= uint.MaxValue)
        {
            buffer[0] = 4;
            bytes = BitConverter.GetBytes((uint)reading);
        }
        else
        {
            buffer[0] = 256 - 8;
            bytes = BitConverter.GetBytes(reading);
        }

        for (int i = 0; i < bytes.Length; i++)
        {
            buffer[i + 1] = bytes[i];
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
{
    byte prefix = buffer[0];

    long result = prefix switch
    {
        2   => BitConverter.ToUInt16(buffer, 1),
        254 => BitConverter.ToInt16(buffer, 1),
        4   => BitConverter.ToUInt32(buffer, 1),
        252 => BitConverter.ToInt32(buffer, 1),
        248 => BitConverter.ToInt64(buffer, 1),
        _   => 0
    };

    return result;
}
}
