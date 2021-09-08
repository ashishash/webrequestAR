using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackerManager : MonoBehaviour
{
    [Header("The length of this list must match the number of images in Reference Image Library")]
    [SerializeField]
    private List<GameObject> ObjectsToPlace;
   // public GameObject  Psearching, Panimation,txtArtName;
    private int refImageCount;
    private Dictionary<string, GameObject> allObjects;

    [SerializeField]
   // private Text currentImageText;

   // public startSplash splashScript;

   // public MarkerVideoTag markerVidScript;
     
    

    //create the “trackable” manager to detect 2D images
    private ARTrackedImageManager arTrackedImageManager;
    private IReferenceImageLibrary refLibrary;

    void Awake()
    {
        //initialized tracked image manager  
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }


    //when the tracked image manager is enabled add binding to the tracked 
    //image changed event handler by calling a method to iterate through 
    //image reference’s changes 
    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    //when the tracked image manager is disabled remove binding to the 
    //tracked image changed event handler by calling a method to iterate 
    //through image reference’s changes
    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void Start()
    {
        refLibrary = arTrackedImageManager.referenceLibrary;
        refImageCount = refLibrary.count;
        LoadObjectDictionary();
    }

    void LoadObjectDictionary()
    {
        allObjects = new Dictionary<string, GameObject>();
        for (int i = 0; i < refImageCount; i++)
        {
            GameObject newOverlay = new GameObject();
            newOverlay = ObjectsToPlace[i];
            //check if the object is prefab and need to be instantiated
            if (ObjectsToPlace[i].gameObject.scene.rootCount == 0)
            {
                newOverlay = (GameObject)Instantiate(ObjectsToPlace[i], transform.localPosition, Quaternion.identity);
            }

            allObjects.Add(refLibrary[i].name, newOverlay);
            newOverlay.SetActive(false);
        }
    }


    void ActivateTrackedObject(string imageName)
    {
        Debug.Log("Tracked the target: " + imageName);
        allObjects[imageName].SetActive(true);
        // if(allObjects[imageName].activeInHierarchy == true){
        //        currentImageText.text = imageName;
        //    }
      // currentImageText.text = imageName;
       
       
        // Give the initial image a reasonable default scale
                            

    }

    bool ready ;

    private void UpdateTrackedObject(ARTrackedImage trackedImage)
    {
        
        //if tracked image tracking state is comparable to tracking
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
         //!= TrackingState.Limited
         //
            //set the image tracked ar object to active 
            allObjects[trackedImage.referenceImage.name].SetActive(true);

             
             //  currentImageText.text = trackedImage.referenceImage.name;
               
             
          
            allObjects[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
            allObjects[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
        }

        
        else //if tracked image tracking state is limited or none 
        {

           
            //deactivate the image tracked ar object 
            allObjects[trackedImage.referenceImage.name].SetActive(false);
             
               
               
             
           // currentImageText.text = "Name of Art Piece";
           
        }
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // for each tracked image that has been added
        foreach (var addedImage in args.added)
        {
            ActivateTrackedObject(addedImage.referenceImage.name);
            //    Psearching.SetActive(false);
            //    txtArtName.SetActive(true);
            //Panimation.SetActive(true);

          //   if(addedImage.referenceImage.name == "Picasso"){
          ////  markerVidScript.markerFound = true;
          //   }else{
          //      // markerVidScript.markerFound = false;
          //  //     markerVidScript.markerStop();
          //   }
           
             allObjects[addedImage.referenceImage.name].transform.localScale = 
                new Vector3(-addedImage.referenceImage.size.x, 0.005f, -addedImage.referenceImage.size.y);

           

            
        }

        // for each tracked image that has been updated
        foreach (var updated in args.updated)
        {
            //if(splashScript.startRecord == false){
            //     Psearching.SetActive(false);
            //     txtArtName.SetActive(true);
            
            //}
            
            //throw tracked image to check tracking state
            UpdateTrackedObject(updated);
         //   currentImageText.text = updated.referenceImage.name;
           allObjects[updated.referenceImage.name].transform.localScale = 
               new Vector3(-updated.referenceImage.size.x, 0.005f, -updated.referenceImage.size.y);

              
        }

        // for each tracked image that has been removed  
        foreach (var trackedImage in args.removed)
        {
            // destroy the AR object associated with the tracked image
          //  Destroy(trackedImage.gameObject);
          //  trackedImage.gameObject.SetActive(false);
           // Psearching.SetActive(true);
           // Panimation.SetActive(false);
            //currentImageText.text = "Name of Art Piece";
            // currentImageText.text = trackedImage.referenceImage.name;
        }
    }


  public  void testFun(){
         foreach (var trackedImage in arTrackedImageManager.trackables)
    {
        
                 // currentImageText.text = "test " + trackedImage.referenceImage.name;
    }

    
    }

    private void Update() {
      //  testFun();
    }


}//clss
