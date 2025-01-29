import { DialogContent, DialogDescription, DialogHeader, DialogTitle, DialogTrigger } from "@/src/components/ui/dialog";
import { CHero, CPower } from "@/src/types";
import { Dialog } from "@kobalte/core/dialog";
import { createSignal, Setter } from "solid-js";
import { createStore } from "solid-js/store";
import PowerBadge, { SIZE } from "../Badges/PowerBadge";
import Hero from "@/src/Pages/Hero";
import { API, Auth } from "@/src/Services/Api";

const [formElements, setFormElements] = createStore<CHero>({
  id:0,
  name:"",
  alias:"",
  powers: [],
  bio:"",
  profileImage:""
});

const selected = {}


function resetForm(){
  setFormElements({
    id:0,
    name:"",
    alias:"",
    powers: [],
    bio:"",
    profileImage:""
  })

  for(const key in selected){
    delete selected[key]
  }
}

interface Props {
  powers: Array<CPower>
}

const [open, setOpen] = createSignal(false);
const AddHeroDialog = (props:Props) =>{
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
        <Form powers={props.powers}/>

      </DialogContent>
    </Dialog>
  )

}


const Form = (props:Props)=>{


  function handleSubmit(e:SubmitEvent){
    e.preventDefault()
    const pws:Array<CPower> = []
    const hero = new CHero(
      formElements.id,
      formElements.name,
      formElements.alias,
      pws,
      formElements.bio,
      formElements.profileImage,
    )

    for (const key in selected){
      pws.push(selected[key])
    }
    API.Heroes.Add(hero)
    resetForm()
    setOpen(false)
  }

  function handleBadgeClick(e:MouseEvent,setActive:Setter<boolean>, power:CPower){
    const name = power.name
    if (selected[name]){
      setActive(false)
      delete selected[name]
    }else{
      setActive(true)
      selected[name] = power
    }
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

      <div class="flex w-full flex-wrap gap-1 justify-between">
        {props.powers.map((power) => (
          <PowerBadge power={power} size={SIZE.sm} onClick={handleBadgeClick} active={selected[power.name]}/>
        ))}
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
