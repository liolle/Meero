import MainLayout from "@/src/Pages/Layouts/MainLayout"
import { createSignal, For, onMount } from "solid-js"
import { CHero } from "../types" 

const [heroes,setHeroes] = createSignal<Array<CHero>>(null)

const Hero = () => {

  onMount(async ()=>{
    try {
      
    } catch (error) {
      
    }
  })

  return (
    <MainLayout>
      <div class="h-full w-full flex justify-center items-center">
        <For each={heroes()} fallback={<></>}>
          {(item, index) => (
            <HeroCard hero={item}/>
          )}
        </For>

      </div>
    </MainLayout>
  )
}

interface HeroCardProps {
  hero: CHero
}

const HeroCard = (props:HeroCardProps)=>{
  return (
  <div class="flex flex-col gap-2">
      <span>{props.hero.name}</span>
      <span>{props.hero.alias}</span>
      <span>{props.hero.id}</span>
  </div>
  )
}



export default Hero
