using WindowsHelper;

namespace WindowsHelperTests;

public class RecycleBinHelperTests : IDisposable
{
    private readonly RecycleBinFlags _flags;

    public RecycleBinHelperTests()
    {
        _flags = RecycleBinFlags.NoConfirmation
            | RecycleBinFlags.NoProgressUI
            | RecycleBinFlags.NoSound;
    }

    public void Dispose()
    {
        RecycleBinHelper.EmptyRecycleBin(string.Empty, _flags);
        GC.SuppressFinalize(this);
    }

    [Fact]
    public void GetItemCount()
    {
        RecycleBinHelper.EmptyRecycleBin(string.Empty, _flags);

        string fileName = Path.GetTempFileName();
        bool result = RecycleBinHelper.Recycle(fileName);

        long itemCount = RecycleBinHelper.GetItemCount(string.Empty);

        Assert.True(result);
        Assert.Equal(1, itemCount);
    }

    [Fact]
    public void GetSize()
    {
        RecycleBinHelper.EmptyRecycleBin(string.Empty, _flags);

        long expectedSize = 1024;
        string fileName = Path.GetTempFileName();
        using (FileStream stream = new(fileName, FileMode.Open, FileAccess.Write, FileShare.None))
        {
            stream.SetLength(expectedSize);
        }

        bool result = RecycleBinHelper.Recycle(fileName);
        long size = RecycleBinHelper.GetSize(string.Empty);

        Assert.True(result);
        Assert.Equal(expectedSize, size);
    }

    [Fact]
    public void EmptyRecycleBin()
    {
        RecycleBinHelper.EmptyRecycleBin(string.Empty, _flags);

        string fileName = Path.GetTempFileName();
        
        bool result = RecycleBinHelper.Recycle(fileName)
            && RecycleBinHelper.EmptyRecycleBin(string.Empty, _flags);

        Assert.True(result);
    }

    [Fact]
    public void RecycleFile()
    {
        RecycleBinHelper.EmptyRecycleBin(string.Empty, _flags);

        string fileName = Path.GetTempFileName();

        bool result = RecycleBinHelper.Recycle(fileName);

        Assert.True(result);
    }
}