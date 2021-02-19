import React, {useState, useEffect} from 'react';
import { Button, Form, Header, Segment } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

export default function SurveyForm({survey}) {
    const { id, name, questions } = survey;
    const initialState = {
        name: '',
        email: '',
        surveyId: id,
        answers: []
    }
    const [surveyResponse, setSurveyResponse] = useState(initialState);
    const [answers, setAnswers] = useState(questions.map(question => (
        {
            questionId: question.id,
            questionAnswer: ''
        }
    )));

    function handleFormSubmit() {
        console.log(answers);
    }

    function handleInputChange(e, { value }) {
        const result = value.split('_');
        const selectedQuestionId = parseInt(result[0]);
        const selectedAnswer = result[1];
        const newAnswer = {
            questionId: selectedQuestionId,
            questionAnswer: selectedAnswer
        }
        setAnswers([...answers.filter(a => a.questionId !== selectedQuestionId), newAnswer]);
    }

    return (
        <Segment clearing>
            <Header content={name} />
            <Form onSubmit={handleFormSubmit}>
                {questions.map(question => (
                    <Form.Group grouped key={question.id}>
                        <label>{question.title}</label>
                        {question.options.map(option => (
                            <Form.Radio 
                                key={option.id}
                                label={option.text}
                                value={`${question.id}_${option.text}`}
                                checked={answers.find(a => a.questionId === question.id).questionAnswer === option.text}
                                onChange={handleInputChange}
                            />
                        ))}
                    </Form.Group>
                ))}
                <Button type='submit' floated='right' positive content='Submit' />
                <Button as={Link} to={'/surveys'} type='submit' floated='right' positive content='Cancel' />
            </Form>
        </Segment>
    );
}