import re
from typing import Dict
from pdfminer.high_level import extract_text
import docx

from transformers import AutoTokenizer, AutoModelForTokenClassification
from transformers import pipeline

# Load LegalBERT and a compatible NER model
# Note: LegalBERT alone does not include a NER head, so we use a pretrained NER model
# You can later fine-tune LegalBERT for legal-specific NER
# model_name = "Jean-Baptiste/roberta-large-ner-english"
model_name = "dbmdz/bert-large-cased-finetuned-conll03-english"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForTokenClassification.from_pretrained(model_name)
legal_ner = pipeline("ner", model=model, tokenizer=tokenizer, aggregation_strategy="simple")

def extract_text_from_docx(file_path: str) -> str:
    doc = docx.Document(file_path)
    return "\n".join([para.text for para in doc.paragraphs])

def extract_legal_bert_entities(text: str) -> Dict:
    results = legal_ner(text)
    entities = {}
    for ent in results:
        label = ent["entity_group"]
        entities.setdefault(label, []).append(ent["word"])
    return entities

def detect_clauses(text: str) -> Dict[str, bool]:
    # clauses = ["non-compete", "termination", "confidentiality", "liability"]
    clauses = ["contrat de travail", "periode", "rupture", "fonctions"]
    detected = {}
    for clause in clauses:
        detected[clause] = bool(re.search(clause, text, re.IGNORECASE))
    return detected

def analyze_document(file_path: str, file_type: str) -> Dict:
    if file_type == "pdf":
        text = extract_text(file_path)
    elif file_type == "docx":
        text = extract_text_from_docx(file_path)
    else:
        raise ValueError("Unsupported file type")

    entities = extract_legal_bert_entities(text)
    clauses = detect_clauses(text)

    return {
        "entities": entities,
        "clauses": clauses,
        "preview": text[:1000]  # return first 1000 characters
    }