<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>C:\source\Mandelbrot\bin\Release\Mandelbrot.dll</Reference>
  <Reference Relative="..\..\..\Microsoft Visual Studio Async CTP\Samples\AsyncCtpLibrary.dll">&lt;Personal&gt;\Microsoft Visual Studio Async CTP\Samples\AsyncCtpLibrary.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Reactive Extensions SDK\v1.1.10621\Binaries\.NETFramework\v4.0\System.Reactive.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Reactive Extensions SDK\v1.1.10621\Binaries\.NETFramework\v4.0\Microsoft.Reactive.Testing.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Reactive Extensions SDK\v1.1.10621\Binaries\.NETFramework\v4.0\System.Reactive.Providers.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Reactive Extensions SDK\v1.1.10621\Binaries\.NETFramework\v4.0\System.Reactive.Windows.Forms.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Reactive Extensions SDK\v1.1.10621\Binaries\.NETFramework\v4.0\System.Reactive.Windows.Threading.dll</Reference>
  <Reference>&lt;ProgramFiles&gt;\Microsoft Corporation\TPL Dataflow\System.Threading.Tasks.Dataflow.dll</Reference>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Reactive</Namespace>
</Query>

var rectangles = @"-2,-1.2,2.5,2.4
-1.56510416666667,-0.5433125,0.625,0.390625
-1.32975260416667,-0.45346875,0.15625,0.09765625
-1.28190104166667,-0.420672526041667,0.0390625,0.0244140625
-1.25608317057292,-0.407061686197917,0.009765625,0.006103515625
-1.25117492675781,-0.404783040364583,0.00244140625,0.00152587890625
-1.25024922688802,-0.404214650472005,0.0006103515625,0.0003814697265625
-1.25002638498942,-0.404072552998861,0.000152587890625,9.5367431640625E-05
-1.24998331069946,-0.404050062179565,3.814697265625E-05,2.38418579101563E-05
-1.24996862808863,-0.404041618188222,9.5367431640625E-06,5.96046447753906E-06
-1.24996516108513,-0.404039447585742,2.38418579101563E-06,1.49011611938477E-06
-1.2499643030266,-0.404038858989875,5.96046447753906E-07,3.72529029846191E-07
-1.2499640804405,-0.404038714634875,1.49011611938477E-07,9.31322574615479E-08
-1.24996402277611,-0.404038679787889,3.72529029846191E-08,2.3283064365387E-08
-1.24996400845703,-0.404038671328376,9.31322574615479E-09,5.82076609134674E-09
-1.24996400423697,-0.40403866900492,2.3283064365387E-09,1.45519152283669E-09
-1.24996400342085,-0.40403866847135,5.82076609134674E-10,3.63797880709171E-10
-1.24996400321136,-0.404038668333713,1.45519152283669E-10,9.09494701772928E-11
-1.24996400315626,-0.40403866829991,3.63797880709171E-11,2.27373675443232E-11
-1.24996400314308,-0.404038668291592,9.09494701772928E-12,5.6843418860808E-12
-1.24996400313962,-0.404038668289598,2.27373675443232E-12,1.4210854715202E-12
-1.24996400313876,-0.404038668289085,5.6843418860808E-13,3.5527136788005E-13"
	.Split ('\n')
	.Select (line => Rect.Parse (line.Trim()))
	.Interpolate(15);

string renderFolder = @"c:\Mandelbrot";
if (!Directory.Exists (renderFolder)) Directory.CreateDirectory (renderFolder);

int imageIndex = 0;
foreach (var rect in rectangles)
{
	Console.Write ("Rendering... ");
	var frame = new Mandelbrot.Frame (rect, 600, 400, renderNow:true);
	
	Console.Write ("Encoding... ");
	MemoryStream pngStream = frame.EncodeToPng();
	
	Console.Write ("Saving... ");
	using (var fileStream = File.Create (
		renderFolder + @"\frame" + imageIndex++.ToString ("D5") + ".png"))
			pngStream.WriteTo (fileStream);
		
	Console.WriteLine ("Done");
}