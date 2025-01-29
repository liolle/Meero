import MainLayout from "@/src/Pages/Layouts/MainLayout"
import { createSignal, For, onMount } from "solid-js"
import { CHero, CPower } from "../types" 
import { API } from "../Services/Api"
import AddHeroDialog from "../Components/Dialogs/AddHero"
import PowerBadge, { SIZE } from "../Components/Badges/PowerBadge"
import { powers, setPowers } from "./Power"
export const [heroes,setHeroes] = createSignal<Array<CHero>>(null)
const Hero = () => {
  onMount(async ()=>{
    try {
      setHeroes(await API.Heroes.GetAll()) 
      setPowers(await API.Powers.GetAll()) 
    } catch (error) {
      console.log(error) 
    }
  })

  return (
    <MainLayout>
      <div class="h-[calc(100vh-80px)] w-full flex flex-col  overflow-y-scroll scrollbar-hidden">
        <div class="flex h-fit min-h-screen flex-col ">
          <div class="px-8 sticky left-0 top-0 z-10  backdrop-blur-sm "> 
            <AddHeroDialog powers={powers()}/>
          </div>

          <div class="h-full w-full flex justify-start items-start gap-8 px-8 pt-4 flex-wrap">
            <For each={heroes()} fallback={<></>}>
              {(item, index) => (
                <HeroCard hero={item}/>
              )}
            </For>
          </div>
        </div>
      </div>
    </MainLayout>
  )
}

interface HeroCardProps {
  hero: CHero
}

const HeroCard = (props:HeroCardProps)=>{
  return (
    <div class="w-[12rem] h-[22rem] overflow-hidden bg-white rounded-2xl shadow-lg p-4 hover:shadow-xl transition-shadow cursor-pointer text-mono border select-none hover:border-[var(--accent)] ">
      {props.hero.profileImage && (
        <img
          src={props.hero.profileImage}
          alt={`${props.hero.name}'s profile`}
          class=" h-40 object-cover rounded-xl"
        />
      )}

      {/* Hero Details */}
      <div class="flex flex-col gap-1">
        <span class="text-md font-bold text-gray-800">{props.hero.alias}</span>
        {
          props.hero.name &&  <span class="text-sm text-gray-600 italic">{props.hero.name}</span>
        }

        {/* Powers */}
        {props.hero.powers.length > 0 && (
          <div>
            <h4 class=" text-md text-gray-800 font-semibold">Powers</h4>
            <div class="flex w-full flex-wrap gap-1 justify-between">
              {props.hero.powers.map((power) => (
                <PowerBadge size={SIZE.sm} power={power} />
              ))}
            </div>
          </div>
        )}

      </div>
    </div>
  );  
}

export default Hero
