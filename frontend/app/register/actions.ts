"use server";

import { UserRegisterFormSchema } from "./validators/UserRegisterValidator";

interface IResponse{
    
}

export async function registerUserAction(formData: FormData) {
    const data = Object.fromEntries(formData);

    const parsed = UserRegisterFormSchema.safeParse(data);

    if (!parsed.success) {
        return { error: "Dados inválidos" };
    }

    const response = await fetch(
        `${process.env.BACKEND_URL_BASE}/user`,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        }
    );

   


    if (response.status!=204) {
         const body =await response.json()
        throw new Error(body.detail)
        // return { error: result.message };
    }

    return { success: true };
}
