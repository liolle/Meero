import { useNavigate } from "@solidjs/router";
import { createSignal } from "solid-js";
import { Auth } from "../Services/Api";

const Register = () => {
  return (
  <div class=" h-full flex justify-center items-center">
      <Form/>
  </div>
  )
}

function Form() {
  // Create signals to manage form state
  const [name, setName] = createSignal("");
  const [email, setEmail] = createSignal("");
  const [password, setPassword] = createSignal("");
  const [formMessage, setFormMessage] = createSignal("");
  const navigate = useNavigate()

  // Handle form submission
  const handleSubmit = async (event) => {
    event.preventDefault(); // Prevent default form submission

    // Perform validation (you can customize this as needed)
    if (!name() || !email() || !password()) {
      setFormMessage("All fields are required.");
      return;
    }

    const auth_message = await Auth.Register(name(),email(),password()) 
    if (auth_message != ""){
      console.log(auth_message)
      return
    }

    navigate("/login")
  };

  return (
    <div class="max-w-md mx-auto p-4 text-neutral-200">
      <h2 class="text-2xl font-bold mb-4">Register</h2>
      <form onSubmit={handleSubmit} class="space-y-4">
        <div>
          <label for="name" class="block text-sm font-medium mb-1">Name:</label>
          <input
            id="name"
            type="text"
            value={name()}
            onInput={(e) => setName(e.target.value)}
            required
            class="w-full text-neutral-800 p-2 border border-gray-300 rounded"
          />
        </div>

        <div>
          <label for="email" class="block text-sm font-medium mb-1">Email:</label>
          <input
            id="email"
            type="email"
            value={email()}
            onInput={(e) => setEmail(e.target.value)}
            required
            class="w-full text-neutral-800 p-2 border border-gray-300 rounded"
          />
        </div>

        <div>
          <label for="password" class="block text-sm font-medium mb-1">Password:</label>
          <input
            id="password"
            type="password"
            value={password()}
            onInput={(e) => setPassword(e.target.value)}
            required
            pattern=".{5,}"
            title="Password must be 5 or more characters"
            class="w-full p-2 border text-neutral-800 border-gray-300 rounded"
          />
        </div>

        <button
          type="submit"
          class="w-full p-2 bg-blue-500 text-white rounded hover:bg-blue-600"
        >
          Register
        </button>
      </form>

     </div>
  );
}

export default Register
