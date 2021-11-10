using System;
using System.Linq;
using Community.VisualStudio.Toolkit;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    [Command(PackageGuids.guidInsertNanoIdCmdSetString, PackageIds.cmdInsertNanoId)]
    public class InsertNanoIdCommand : BaseCommand<InsertNanoIdCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = docView.TextView?.Selection.SelectedSpans.FirstOrDefault();

#pragma warning disable VSTHRD103 // Call async methods when in an async method
            // async was slowing it down a bit
            docView?.TextBuffer.Replace(selection.Value, Nanoid.Nanoid.Generate("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 12));
#pragma warning restore VSTHRD103 // Call async methods when in an async method
        }
    }
}
