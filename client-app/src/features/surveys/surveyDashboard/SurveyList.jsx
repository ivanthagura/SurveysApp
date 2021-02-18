import React from 'react';
import SurveyListItem from './SurveyListItem';

export default function SurveyList({surveys}) {
    return (
        <>
            {surveys.map(survey => (
                <SurveyListItem survey={survey} key={survey.id}/>
            ))}
        </>
    );
}