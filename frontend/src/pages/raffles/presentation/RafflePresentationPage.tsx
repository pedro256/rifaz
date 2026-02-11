import { useParams } from "react-router"

export default function RafflePresentationPage(){

    const params = useParams()
    return (
        <main>
            {JSON.stringify(params)}
            Apresentação da Rifa
        </main>
    )
}