import { z } from "zod"

const UserRegisterFormSchema = z.object({
  fullname: z.string().nonempty("Fullname is required").min(5,{error:"Fullname should have more that 5 characters"}),
  email: z.email({error:'Invalid Email'}).nonempty("Password is required").min(5,{error:"Username should have more that 5 characters"}),
  password: z.string()
    .nonempty("Password is required"),
  confirm_password: z.string()
    .nonempty("Confirm password is required")
})
.refine(({ password, confirm_password}) => password === confirm_password, {
  message: "Password doesn't match",
  path: ["confirm_password"]
})
export type UserRegisterFormType = z.infer<typeof UserRegisterFormSchema>;

export {
    UserRegisterFormSchema
};