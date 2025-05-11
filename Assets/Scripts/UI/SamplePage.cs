using UnityEngine;

public class SamplePage : PageBase
 {
    public override void Show(object data = null)
    {
        base.Show(data);
        debug.log("SamplePage shown triggered with data: " + data);
    }
}