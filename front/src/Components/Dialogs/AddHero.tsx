import { DialogContent, DialogDescription, DialogHeader, DialogTitle, DialogTrigger } from "@/src/components/ui/dialog";
import { CHero } from "@/src/types";
import { Dialog } from "@kobalte/core/dialog";
import { createSignal } from "solid-js";
import { createStore } from "solid-js/store";

const [formElements, setFormElements] = createStore<CHero>({
  id:0,
  name:"",
  alias:"",
  powers: [],
  bio:"",
  profileImage:""
});

function resetForm(){
  setFormElements({
    id:0,
    name:"",
    alias:"",
    powers: [],
    bio:"",
    profileImage:""
  })
}

const AddHeroDialog = () =>{
  const [open, setOpen] = createSignal(false);
  return (
    <Dialog modal={true} open={open()} onOpenChange={setOpen}>
      <DialogTrigger >
        <button class="z-10 h-[2rem] bg-neutral-800 text-neutral-200 rounded-lg shadow text-mono text-sm font-bold px-4 py-[.5rem] hover:bg-[var(--accent)] ">
          Add
        </button>
      </DialogTrigger>
      <DialogContent class="sm:max-w-[425px] select-none">
        <DialogHeader>
          <DialogTitle>Add Hero</DialogTitle>
          <DialogDescription>
            Complete all fields to add ad the hero.
          </DialogDescription>
        </DialogHeader>
        <Form/>

      </DialogContent>
    </Dialog>
  )

}


const Form = ()=>{

  function handleSubmit(e:SubmitEvent){
    e.preventDefault()
    resetForm()
  }

  return (
    <form onSubmit={handleSubmit} class="flex flex-col gap-4">
      {/* Name */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Name</label>
        <input
          type="text"
          value={formElements.name}
          onInput={(e) => setFormElements("name", e.currentTarget.value)}
          class="mt-1 p-2 w-full border rounded-md"
          placeholder="Enter hero name"
        />
      </div>

      {/* Alias */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Alias</label>
        <input
          type="text"
          value={formElements.alias}
          required
          onInput={(e) => setFormElements("alias", e.currentTarget.value)}
          class="mt-1 p-2 w-full border rounded-md"
          placeholder="Enter hero alias"
        />
      </div>

      {/* Bio */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Bio</label>
        <textarea
          value={formElements.bio}
          onInput={(e) => setFormElements("bio", e.currentTarget.value)}
          class="mt-1 p-2 w-full border rounded-md"
          placeholder="Enter hero biography"
        />
      </div>

      {/* Profile Image */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Profile Image URL</label>
        <input
          type="url"
          value={formElements.profileImage}
          onInput={(e) => setFormElements("profileImage", e.currentTarget.value)}
          class="mt-1 p-2 w-full border rounded-md"
          placeholder="Enter profile image URL"
        />
      </div>

      {/* Powers */}
      <div>
        <label class="block text-sm font-medium text-gray-700">Powers</label>
        {formElements.powers.map((power, index) => (
          <div  class="flex gap-2 mb-2">
            <input
              type="text"
              value={power.name}
              //onInput={(e) => updatePower(index, "name", e.currentTarget.value)}
              class="flex-1 p-2 border rounded-md"
              placeholder="Power name"
            />
          </div>
        ))}
        <button
          type="button"
          //onClick={addPower}
          class="mt-2 text-sm text-blue-500 hover:underline"
        >
          + Add Power
        </button>
      </div>

      {/* Buttons */}
      <div class="flex justify-between">
        <button
          type="button"
          onClick={resetForm}
          class="bg-gray-500 text-white px-4 py-2 rounded-md hover:bg-gray-600"
        >
          Reset
        </button>
        <button
          type="submit"
          class="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600"
        >
          Save Hero
        </button>
      </div>
    </form>
  )
}

export default AddHeroDialog
