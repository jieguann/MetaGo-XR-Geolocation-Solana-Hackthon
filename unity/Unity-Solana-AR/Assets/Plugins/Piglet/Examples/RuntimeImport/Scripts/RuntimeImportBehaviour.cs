using Piglet;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// This MonoBehaviour provides a minimal example for using
/// Piglet to import glTF models at runtime.
/// </summary>
public class RuntimeImportBehaviour : MonoBehaviour
{
    /// <summary>
    /// The currently running glTF import task.
    /// </summary>
    private GltfImportTask _task;
    //public string URL;
    /// <summary>
    /// Root GameObject of the imported glTF model.
    /// </summary>
    private GameObject _model;
    public string modelURL = null;
    public float scale;
    public GameObject textLoading;
    
    /// <summary>
    /// Unity callback that is invoked before the first frame.
    /// Create the glTF import task and set up callbacks for
    /// progress messages and successful completion.
    /// </summary>
    public void runTask()
    {
        // Note: To import a local .gltf/.glb/.zip file, you may
        // instead pass an absolute file path to GetImportTask
        // (e.g. "C:/Users/Joe/Desktop/piggleston.glb"), or a byte[]
        // array containing the raw byte content of the file.
        
            _task = RuntimeGltfImporter.GetImportTask(
            modelURL);
            _task.OnProgress = OnProgress;
            _task.OnCompleted = OnComplete;
        
            
    }

    /// <summary>
    /// Callback that is invoked by the glTF import task
    /// after it has successfully completed.
    /// </summary>
    /// <param name="importedModel">
    /// the root GameObject of the imported glTF model
    /// </param>
    private void OnComplete(GameObject importedModel)
    {
        _model = importedModel;
        _model.transform.position = transform.position;
        _model.transform.localScale = new Vector3(scale,scale,scale);
        Destroy(textLoading);
        Debug.Log("Success!");
    }

    /// <summary>
    /// Callback that is invoked by the glTF import task
    /// to report intermediate progress.
    /// </summary>
    /// <param name="step">
    /// The current step of the glTF import process.  Each step imports
    /// a different type of glTF entity (e.g. textures, materials).
    /// </param>
    /// <param name="completed">
    /// The number of glTF entities (e.g. textures, materials) that have been
    /// successfully imported for the current import step.
    /// </param>
    /// <param name="total">
    /// The total number of glTF entities (e.g. textures, materials) that will
    /// be imported for the current import step.
    /// </param>
    private void OnProgress(GltfImportStep step, int completed, int total)
    {
        //Debug.LogFormat("{0}: {1}/{2}", step, completed, total);
    }

    /// <summary>
    /// Unity callback that is invoked after every frame.
    /// Here we call MoveNext() to advance execution
    /// of the glTF import task. Once the model has been successfully
    /// imported, we auto-spin the model about the y-axis.
    /// </summary>
    /// 
    /// 
    
    public void Update()
    {
        // advance execution of glTF import task
        if(modelURL != null)
        {
            _task.MoveNext();
        }
        
    }
    

    




}
