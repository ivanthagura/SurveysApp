import React, {useState, useEffect} from 'react';
import SurveyForm from '../surveyForm/SurveyForm';
import agent from '../../../app/api/agent';
import { useHistory } from 'react-router-dom';

export default function SurveyDetailedPage({match}) {
    const history = useHistory();
    const initialSurvey = {
        id: 0,
        name: '',
        questions: []
    };
    const [survey, setSurvey] =  useState(initialSurvey);
    const [dataLoaded, setDataLoaded] = useState(false);

    const getSurvey = async () => {
        try {
            const surveyResponse = await agent.Surveys.details(match.params.id);
            setSurvey(surveyResponse);
            setDataLoaded(true);
        }
        catch(reponse) {
            history.push('/notfound');
        }
    };

    useEffect(() => {
        getSurvey();
    }, []);

    return (
        <>
            <h1>Compass Surveys</h1>
            {dataLoaded ? <SurveyForm survey={survey} /> : <h4>Loading</h4>}
        </>
    );
}