import { z } from "zod"

const SignInFormSchema = z.object({
  username: z.string().nonempty("Username is required").min(5,{error:"Username should have more that 5 characters"}),
  password: z.string().nonempty("Password is required").min(5,{error:"Username should have more that 5 characters"})
});
export type SignInFormType = z.infer<typeof SignInFormSchema>;

export {
    SignInFormSchema
};