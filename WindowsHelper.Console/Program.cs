using System.CommandLine;
using WindowsHelper;

RootCommand root = new("Windows Helper");

Command emptyRecycleBin = CreateEmptyRecycleBin();
Command queryRecycleBin = CreateQueryRecycleBin();
Command recycle = CreateRecycle();

root.Add(emptyRecycleBin);
root.Add(queryRecycleBin);
root.Add(recycle);

return root.Invoke(args);

static Command CreateEmptyRecycleBin()
{
    Command emptyRecycleBin = new(
        name: "empty-recycle-bin",
        description: "Empties the recycle bin on the specified drive.");

    Option<bool> noConfirmation = new(
        name: "--no-confirmation",
        description: "No dialog box confirming the deletion of the objects will be displayed.");
    Option<bool> noProgressUi = new(
        name: "--no-progress-ui",
        description: "No dialog box indicating the progress will be displayed.");
    Option<bool> noSound = new(
        name: "--no-sound",
        description: "No sound will be played when the operation is complete.");
    Option<string> rootPath = new(
           name: "--root-path",
           description: "The path of the root drive on which the Recycle Bin is located.");

    emptyRecycleBin.AddOption(noConfirmation);
    emptyRecycleBin.AddOption(noProgressUi);
    emptyRecycleBin.AddOption(noSound);
    emptyRecycleBin.AddOption(rootPath);

    emptyRecycleBin.SetHandler((rootPath, noConfirmation, noProgressUi, noSound) =>
    {
        RecycleBinFlags flags = noConfirmation ? RecycleBinFlags.NoConfirmation : RecycleBinFlags.None;
        flags |= noProgressUi ? RecycleBinFlags.NoProgressUI : RecycleBinFlags.None;
        flags |= noSound ? RecycleBinFlags.NoSound : RecycleBinFlags.None;

        RecycleBinHelper.EmptyRecycleBin(rootPath, flags);
    },
    rootPath, noConfirmation, noProgressUi, noSound);

    return emptyRecycleBin;
}

static Command CreateQueryRecycleBin()
{
    Command queryRecycleBin = new(
        name: "query-recycle-bin",
        description: "Retrieves the size of the Recycle Bin and the number of items in it, for a specified drive.");

    Option<bool> itemCount = new(
        name: "--item-count",
        description: "The total number of items in the specified Recycle Bin.");
    Option<bool> size = new(
        name: "--size",
        description: "The total size of all the objects in the specified Recycle Bin, in bytes.");
    Option<string> rootPath = new(
           name: "--root-path",
           description: "The path of the root drive on which the Recycle Bin is located.");

    queryRecycleBin.AddOption(itemCount);
    queryRecycleBin.AddOption(rootPath);
    queryRecycleBin.AddOption(size);

    queryRecycleBin.SetHandler((rootPath, itemCount, size) =>
    {
        if (!itemCount && !size)
        {
            Console.WriteLine("Please specify either --item-count or --size.");
            return;
        }

        if (itemCount)
        {
            Console.WriteLine($"Item count: {RecycleBinHelper.GetItemCount(rootPath)}");
        }
        
        if (size)
        {
            Console.WriteLine($"Size: {RecycleBinHelper.GetSize(rootPath)}");
        }
    },
    rootPath, itemCount, size);

    return queryRecycleBin;
}

static Command CreateRecycle()
{
    Command recycle = new(
        name: "recycle",
        description: "Sends a file to the Recycle Bin.");

    Option<string> fileName = new(
        name: "--file-name",
        description: "The name of the file to recycle.")
    { IsRequired = true };

    recycle.AddOption(fileName);

    recycle.SetHandler((fileName) =>
    {
        RecycleBinHelper.Recycle(fileName);
    },
    fileName);

    return recycle;
}