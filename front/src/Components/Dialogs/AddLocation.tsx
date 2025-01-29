import { DialogContent, DialogDescription, DialogHeader, DialogTitle, DialogTrigger } from "@/src/components/ui/dialog";
import { API } from "@/src/Services/Api";
import { CLocation } from "@/src/types";
import { Dialog } from "@kobalte/core/dialog";
import { createSignal } from "solid-js";
import { createStore } from "solid-js/store";

const [formElements, setFormElements] = createStore({
  address: "",
  city: "",
  country: "",
  locationImage: "",
  googleFrame: "",
  isVirtual: false,
});

function resetForm(){
  setFormElements({
    address: "",
    city: "",
    country: "",
    locationImage: "",
    googleFrame: "",
    isVirtual: false,
  });
}

const [open, setOpen] = createSignal(false);

const LocationForm = () => {

  function handleSubmit(e) {
    e.preventDefault();
    API.Location.Add(  
      new CLocation(
        formElements.address, 
        formElements.city, 
        formElements.country, 
        formElements.locationImage, 
        formElements.googleFrame, 
        false
      )
    )
    resetForm()
    setOpen(false)
  }

  return (
    <form onSubmit={handleSubmit} class="flex flex-col gap-4">
      <div>
        <label class="block font-medium">Address</label>
        <input type="text" required placeholder="Enter an address" onInput={(e) => setFormElements("address", e.currentTarget.value)} class="w-full p-2 border rounded-lg" />
      </div>

      <div>
        <label class="block font-medium">City</label>
        <input type="text" required placeholder="Enter a city" onInput={(e) => setFormElements("city", e.currentTarget.value)} class="w-full p-2 border rounded-lg" />
      </div>

      <div>
        <label class="block font-medium">Country</label>
        <input type="text" required placeholder="Enter country" onInput={(e) => setFormElements("country", e.currentTarget.value)} class="w-full p-2 border rounded-lg" />
      </div>

      <div>
        <label class="block font-medium">Location Image URL</label>
        <input type="text" placeholder="Enter a location image URL" onInput={(e) => setFormElements("locationImage", e.currentTarget.value)} class="w-full p-2 border rounded-lg" />
      </div>

      <div>
        <label class="block font-medium">Google Frame URL</label>
        <input type="text" placeholder="Enter a Google frame URL" onInput={(e) => setFormElements("googleFrame", e.currentTarget.value)} class="w-full p-2 border rounded-lg" />
      </div>

      <div class="flex items-center">
        <input type="checkbox" onChange={(e) => setFormElements("isVirtual", e.currentTarget.checked)} class="mr-2" />
        <label class="font-medium">Virtual?</label>
      </div>

      <div class="flex justify-end">
        <button type="submit" class="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600">
          Submit
        </button>
      </div>    </form>
  );
};

const AddLocationDialog = ()=>{

  return (
    <Dialog modal={true} open={open()} onOpenChange={setOpen}>
      <DialogTrigger >
        <button class="z-10 h-[2rem] bg-neutral-800 text-neutral-200 rounded-lg shadow text-mono text-sm font-bold px-4 py-[.5rem] hover:bg-[var(--accent)] ">
          <span>Add</span>
        </button>
      </DialogTrigger>
      <DialogContent class="sm:max-w-[425px] select-none">
        <DialogHeader>
          <DialogTitle>Add Location</DialogTitle>

          <DialogDescription>
            Complete all fields to add ad the location.
          </DialogDescription>

        </DialogHeader>
        <LocationForm/>
      </DialogContent>
    </Dialog>
  )

}

export default AddLocationDialog
