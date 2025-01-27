import logo from "@/src/assets/logo.svg";

const Logo = ()=>{
  return(
    <div class="h-[2rem] w-[2rem] flex justify-center items-center select-none">
      <span class=" h-8 w-8 text-neutral-800">
        <img class=" object-contain h-full w-full " src={logo} alt="" />
      </span>
    </div>
  )
}

export default Logo
